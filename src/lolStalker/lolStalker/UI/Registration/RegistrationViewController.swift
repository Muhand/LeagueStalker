//
//  RegisterationViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/5/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class RegistrationViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let registrationView: RegistrationForm = {
        let view = RegistrationForm()
        return view
    }()
    
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
        registrationView.delegate = self
    }
    
    func setupSubViews() {
        view.addSubview(registrationView)
        hideKeyboardWhenTappedAround()
    }
    
    func setupConstraints() {
        registrationView.translatesAutoresizingMaskIntoConstraints = false
        registrationView.centerXAnchor.constraint(equalTo: self.view.centerXAnchor).isActive = true
        registrationView.centerYAnchor.constraint(equalTo: self.view.centerYAnchor).isActive = true
        registrationView.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 475, referenceHeight: nil, originalHeight: nil)).isActive = true
        registrationView.widthAnchor.constraint(equalTo: self.view.widthAnchor, constant:-(Helper.getWidthOf(xdWidth: 64, referenceWidth: nil, originalWidth: nil))).isActive = true
    }
    
    func setupMargins() {
        self.registrationView.center = self.view.center
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}

////////////////////////////////////
//Conform to registration delegates
////////////////////////////////////
extension RegistrationViewController: registrationFormDelegate {
    func didPressSignup(form: RegistrationForm) {
        print("SIGNING UP...")
    }
    
    func didPressAlreadyHaveAccount(form: RegistrationForm) {
        dismiss(animated: true, completion: nil)
    }
}

