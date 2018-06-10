//
//  SettingsViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/6/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class SettingsViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let logoutBtn: UIButton = {
        let button = UIButton()
        button.setTitle("Logout", for: .normal)
        button.addTarget(self, action: #selector(logoutPressed), for: .touchUpInside)
        return button
    }()
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        print("SETTINGS")
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
        hideKeyboardWhenTappedAround()
    }
    
    func setupSubViews() {
        view.addSubview(logoutBtn)
    }
    
    func setupConstraints() {
        logoutBtn.translatesAutoresizingMaskIntoConstraints = false
        
        logoutBtn.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        logoutBtn.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
    }
    
    func setupMargins() {
        
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
    
    @IBAction func logoutPressed(sender: AnyObject) {
        let loginViewController = LoginViewController()
        UIApplication.shared.keyWindow?.rootViewController = loginViewController
    }
}
